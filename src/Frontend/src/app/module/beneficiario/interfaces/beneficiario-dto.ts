export interface beneficiarioDto {
  id?: number;
  //personId?: number;
  //nombre: string;
  //apellido: string;
  //identification: string;
  //nombreCompleto?: string;
  //email: string;
  //direccion: string;
  //telefono: string;
  //donacion_recibida?: string;
  //tipo_ayuda?: string;
  //description: string;
  //status?: string;

  description: string;
  person: {
    email: string;
    firstName: string;
    identification: string;
    identificationTypeId?: string;
    lastName: string;
    nameCompleted?: string;
    phone: string;
    secondLastName: string;
    secondName: string;
    status?: string;
  }
}
