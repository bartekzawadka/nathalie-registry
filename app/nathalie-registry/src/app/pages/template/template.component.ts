import {Component, OnInit} from '@angular/core';
import {TemplateField} from "../../models/template.field";
import {KeyValue} from "../../models/key.value";
import {TemplatesService} from "../../services/templates.service";
import {FieldFormulaValidator} from "../../helpers/field.formula.validator";
import {Template} from "../../models/template";
import {Router} from "@angular/router";

@Component({
  selector: 'app-template',
  templateUrl: './template.component.html',
  styleUrls: ['./template.component.scss']
})
export class TemplateComponent implements OnInit {

  currentField: TemplateField = new TemplateField();
  templateFieldTypes: Array<KeyValue<number>>;

  template: Template = new Template();

  constructor(private templatesService: TemplatesService,
              private router: Router,) {
  }

  ngOnInit() {
    this.templatesService.getTemplateFieldTypes().then(data => {
      this.templateFieldTypes = data;
    });
  }

  addField() {
    this.template.templateFields.push(this.currentField);
    this.clearField();
  }

  clearField() {
    this.currentField = new TemplateField();
  }

  validateFormula() {
    this.currentField.isFormulaValid = FieldFormulaValidator.isFormulaValid(this.currentField.formula,
      this.template.templateFields);
  }

  removeField(index: number) {
    //TODO: Add checking if can remove (is field referenced in any other field's formula)
    this.template.templateFields.splice(index);
  }

  submit() {
    this.templatesService.addTemplate(this.template).then(()=>{
      alert("OK");
      this.router.navigate(['/templates']);
    }, e=>alert("ERROR: "+e));
  }
}
