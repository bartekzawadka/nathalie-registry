import {RegistryEntityRowField} from "./registry-entity-row-field";
import {KeyValue} from "./key.value";
import {TemplateField} from "./template.field";

export class RegistryEntityRow {
  rowNumber: number = 1;
  columnValues: Array<RegistryEntityRowField> = [];
}
