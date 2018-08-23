import {TemplateField} from "../models/template.field";

export class FieldFormulaValidator {
  static regex = /\[(.*?)\]|[*+-/]/g;

  public static isFormulaValid(formula: string, fieldNames: Array<TemplateField>): boolean{
    if(!formula){
      return false;
    }

    formula = formula.trim();
    let result = formula.match(this.regex);

    let fields = [];
    let operators = [];

    for(let k in result){
      let fieldsMatchArray = result[k].match(/\[(.*?)\]/g);
      if(fieldsMatchArray){
        if(!fieldNames.find(a=> a.type.value !== 0 && "["+a.name.toLowerCase()+"]" === fieldsMatchArray[0].toLowerCase())){
          return false;
        }
        fields.push(fieldsMatchArray[0]);
        continue;
      }
      let operatorsMatchArray = result[k].match(/[*+-/]/g);
      if(operatorsMatchArray){
        operators.push(operatorsMatchArray[0]);
      }
    }

    if(!fieldNames || fieldNames.length == 0){
      return false;
    }

    if(operators.length != fields.length-1 || operators.length == 0){
      return false;
    }

    return true;
  }
}
