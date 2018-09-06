import {Template} from "./template";

export class Registry {
  public id: string;
  public templates: Template[];
  public registryDate: Date;
  public registryEntities: Array<any>;
}
