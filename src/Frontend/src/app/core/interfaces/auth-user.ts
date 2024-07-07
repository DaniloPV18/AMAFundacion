export class AuthenticationConfiguration {
    clientId!: string;
    authority!: string;
    redirectUri!: string;
    postLogoutRedirectUri!: string;
    scopes!: string[];
    constructor(init?: Partial<AuthenticationConfiguration>) {
      Object.assign(this, init);
    }
  }
  export interface AuthUser {
    firstName?: string;
    lastName?: string;
    name?: string;
    id: string;
    email: string;
  }
