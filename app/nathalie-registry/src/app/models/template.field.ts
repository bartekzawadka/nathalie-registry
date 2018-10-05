export class TemplateField{
  public name: string;
  public fieldType: number;
  public isCalculated: boolean = false;
  public isSum: boolean = false;
  public formula: string;
  public isFormulaValid: boolean = true;
  public value: any;
}
