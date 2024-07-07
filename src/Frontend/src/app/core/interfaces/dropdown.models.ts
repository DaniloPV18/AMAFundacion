export interface ItemDropdown {
    code: string;
    description: string;
    dataSerialize?: string;
}

export interface DynamicDataToDialog {
    Params: any[];
}

export interface ConfigurationDropdownProp {
    Id: string;
    Name: string;
    Tooltip: string;
    Dataset: string;
    NameComponent: string;
}

export interface ChangeItemDropdown {
    conf: ConfigurationDropdownProp;
    data: ItemDropdown;
}