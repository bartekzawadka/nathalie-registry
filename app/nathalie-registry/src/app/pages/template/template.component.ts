import {Component, OnInit} from '@angular/core';
import {TemplateField} from "../../models/template.field";
import {KeyValue} from "../../models/key.value";
import {TemplatesService} from "../../services/templates.service";
import {Template} from "../../models/template";
import {ActivatedRoute, Params, Router} from "@angular/router";
import {MatDialog, MatDialogConfig} from "@angular/material";
import {FieldEditComponent} from "../modals/field-edit/field-edit.component";
import {TemplateContext} from "../../models/template-context";

@Component({
  selector: 'app-template',
  templateUrl: './template.component.html',
  styleUrls: ['./template.component.scss']
})
export class TemplateComponent implements OnInit {
  template: Template = new Template();
  templateFieldTypes: Array<KeyValue<number>>;

  constructor(private templatesService: TemplatesService,
              public dialog: MatDialog,
              private route: ActivatedRoute,
              private router: Router) {

    this.route.params.subscribe((p: Params) => {
      if (!p || !p['id']) {
        return;
      }

      this.templatesService.getTemplate(p['id']).then(data => {
        this.template = data;
      });
    });
  }

  ngOnInit() {
    this.templatesService.getTemplateFieldTypes().then(data => {
      this.templateFieldTypes = data;
    });
  }

  addField(templateField: TemplateField) {
    this.template.templateFields.push(templateField);
  }

  getFieldTypeName(fieldTypeValue: number) {
    if (!this.templateFieldTypes || this.templateFieldTypes.length == 0) {
      return;
    }

    return this.templateFieldTypes.find(field => field.value == fieldTypeValue).key;
  }

  editField(field: TemplateField, index: number){

    let editedField = new TemplateField();
    editedField.fieldType = field.fieldType;
    editedField.name = field.name;
    editedField.isCalculated = field.isCalculated;
    editedField.formula = field.formula;
    editedField.isSum = field.isSum;

    let templateContext = new TemplateContext();
    templateContext.templateField = editedField;
    templateContext.templateFields = this.template.templateFields;
    templateContext.templateFieldTypes = this.templateFieldTypes;

    const ref = this.dialog.open(FieldEditComponent, <MatDialogConfig>{
      disableClose: true,
      data: templateContext,
      panelClass: 'dialog'
    });

    ref.afterClosed().subscribe(data => {
      if(!data){
        return;
      }

      this.template.templateFields[index] = data;
    });
  }


  removeField(field: TemplateField, index: number) {
    if (this.template.templateFields && this.template.templateFields.length > 0) {
      if (this.template.templateFields
        .find(element => element.formula && element.formula.indexOf(field.name) >= 0)) {
        //TODO: Replace with message dialog
        alert("'"+field.name+"' is referenced in other field's formula");
        return;
      }
    }

    this.template.templateFields.splice(index, 1);
  }

  submit() {

    //TODO: Check if there is only one SUM field

    this.templatesService.upsertTemplate(this.template).then(() => {
      alert("OK");
      this.router.navigate(['/templates']);
    }, e => {
      //TODO: Replace with message dialog
      alert("ERROR: " + e);
    });
  }
}
