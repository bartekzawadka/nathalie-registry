import {TemplateField} from "./template.field";
import {KeyValue} from "./key.value";

export class TemplateContext {
  public templateField: TemplateField;
  public templateFields: Array<TemplateField>;
  public templateFieldTypes: Array<KeyValue<string, number>>;
}
