import {Template} from "./template";
import {RegistryEntityRow} from "./registry-entity-row";

export class RegistryEntity {
  public id: string;
  public template: Template;
  public registryDate: Date;
  public isFilledIn: boolean;
  public dataIds: Array<string>;
  public data: Array<RegistryEntityRow> = [];
}
