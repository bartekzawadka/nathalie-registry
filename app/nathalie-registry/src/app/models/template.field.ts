import {KeyValue} from "./key.value";

export class TemplateField{
  public name: string;
  public type: KeyValue<number>;
  public isCalculated: boolean = false;
  public isSum: boolean = false;
  public formula: string;
  public isFormulaValid: boolean = true;
}
