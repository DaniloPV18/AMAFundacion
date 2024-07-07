import { Nullable } from "primeng/ts-helpers";

export interface IUserForm {
  id: number;
  identification: string;
  name: string;
  email: string;
  status: string;
  password?: string | null;
}

export interface IUserUpdateForm {
  id: number;
  identification: string;
  name: string;
  email: string;
  status: string;
  password?: Nullable;
}
