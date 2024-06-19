export class MenuItem implements IMenuItem{
    id?: string;
    text?: string;
    action?: string;
    icon?: string;
    menuFatherId?: string;
    children?: any[];
    order?: number;
    isCollapsed?: any;
    name!:string;
    iconClasses!: string ;
    path?: any;
  }

   export interface IMenuItem {
    id?: string | null;
    text?: string| null;
    action?: string| null;
    icon?: string| null;
    menuFatherId?: string| null;
    children?: any[]| null;
    order?: number| null;
    isCollapsed?: any| null;
    name:string;
    iconClasses: string ;
    path?: any| null;
    }
  export interface RequestPaginated {
    offset: number;
    take: number;
    sort?: string;
  }
