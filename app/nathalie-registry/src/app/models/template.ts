import {TemplateField} from "./template.field";

export class Template {
  public templateFields: Array<TemplateField> = [];
  public name: string;
  public isEnabled: boolean = true;
}
