import { Component, OnInit } from '@angular/core';
import {TemplateField} from "../../models/template.field";
import {KeyValue} from "../../models/key.value";
import {TemplatesService} from "../../services/templates.service";

@Component({
  selector: 'app-template',
  templateUrl: './template.component.html',
  styleUrls: ['./template.component.scss']
})
export class TemplateComponent implements OnInit {

  currentField: TemplateField = new TemplateField();
  templateFields: Array<TemplateField> = [];
  templateFieldTypes: Array<KeyValue<number>>;

  constructor(private templatesService: TemplatesService) { }

  ngOnInit() {
    this.templatesService.getTemplateFieldTypes().then(data=>{
      this.templateFieldTypes = data;
    });
  }

  addField(){
    this.templateFields.push(this.currentField);
    this.clearField();
  }

  clearField(){
    this.currentField = new TemplateField();
  }
}
