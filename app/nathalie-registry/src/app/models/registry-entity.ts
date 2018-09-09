import {Template} from "./template";

export class RegistryEntity {
  public id: string;
  public template: Template;
  public registryDate: Date;
  public isFilledIn: boolean;
  public dataIds: Array<string>;
  public data: Array<any>;
}
