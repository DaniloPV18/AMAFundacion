import { DataGridOptions } from "../../../core/interfaces/data-grid-options";

 
 

export interface PersonaRequestPaginated extends DataGridOptions {
    DocumentoIdentidad: string | null;
    Nombre: string | null;
    Apellido: string | null;
    Activo: boolean | null;
}
