import { MenuItem } from "./menu-item.model";

export class ExpansibleMenuItem {
    title: string;
    icon: string;
    items: MenuItem[];
    dl?: string;
    canShow?: boolean;
}