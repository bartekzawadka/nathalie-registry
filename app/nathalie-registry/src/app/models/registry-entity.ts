import {Template} from "./template";

export class RegistryEntity {
  public id: string;
  public template: Template;
  public registryDate: Date;
  public isFilledIn: boolean;
  public data: Array<any>;
}
