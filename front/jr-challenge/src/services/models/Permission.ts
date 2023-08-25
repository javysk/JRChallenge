import { PermissionType } from "./PermissionType";

export interface Permission {
  id: number;
  name: string;
  surName: string;
  permissionDate: Date;
  permissionType: PermissionType;
}