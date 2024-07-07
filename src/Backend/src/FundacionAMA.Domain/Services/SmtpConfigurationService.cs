using FundacionAMA.Domain.Shared.Interfaces;

using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace FundacionAMA.Domain.Services;

public class SmtpConfigurationService : ISmtpConfigurationService
{
    private readonly ISmtpConfigurationRepository _repository;
    private readonly IClaimsService _claimsService;
    private readonly string _encryptionKey = "DEB9EA203AC09F46AE5F62BEB7CCC200";
    public SmtpConfigurationService(ISmtpConfigurationRepository repository, IClaimsService claimsService)
    {
        _repository = repository;
        _claimsService = claimsService;
    }

    public SmtpConfiguration? GetById(int id)
        =>
        _repository.GetById(id);



    public IEnumerable<SmtpConfiguration> GetAll(Expression<Func<SmtpConfiguration, bool>>? filter = null)
        =>
        _repository.GetAll(filter);

    public void Create(SmtpConfiguration obj)
    {
        obj.Password = encrypt(obj.Password);

        if (obj is IAudit)
        {
            obj.CreatedAt = DateTime.Now;
            obj.CreatedBy = _claimsService.UserId;
        }

        _repository.Insert(obj);
    }

    public void Update(SmtpConfiguration obj)
    {
        if (obj is IAudit && _claimsService.Autenticated)
        {
            obj.UpdatedAt = DateTime.Now;
            obj.UpdatedBy = _claimsService.UserId;
        }
        _repository.Update(obj);
    }

    public SmtpConfiguration GetByProfileId(int id)
    {
        var _profile = _repository.First(a => a.Profile == id);
        _profile.Password = decrypt(_profile.Password);
        return _profile;
    }

    public void UpdatePassword(SmtpConfiguration obj)
    {

        obj.Password = encrypt(obj.Password);

        if (obj is IAudit && _claimsService.Autenticated)
        {
            obj.CreatedAt = DateTime.Now;
            obj.CreatedBy = _claimsService.UserId;
        }

        _repository.Update(obj);
    }


    private string encrypt(string plainText)
    {
        using (Aes aesAlg = Aes.Create())
        {



            aesAlg.Key = Encoding.UTF8.GetBytes(_encryptionKey);
            aesAlg.IV = new byte[16];

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }

    private string decrypt(string cipherText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(_encryptionKey);
            aesAlg.IV = new byte[16];

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}
