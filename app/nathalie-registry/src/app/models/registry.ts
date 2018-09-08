import {Template} from "./template";
import {RegistryEntity} from "./registry-entity";

export class Registry {
  public id: string;
  public registryDate: Date;
  public registryEntities: Array<RegistryEntity>;
}
