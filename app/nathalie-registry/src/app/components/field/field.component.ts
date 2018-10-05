import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {TemplatesService} from "../../services/templates.service";
import {KeyValue} from "../../models/key.value";
import {TemplateField} from "../../models/template.field";

@Component({
  selector: 'app-field',
  templateUrl: './field.component.html',
  styleUrls: ['./field.component.scss']
})
export class FieldComponent implements OnInit {

  @Input('templateFieldTypes') templateFieldTypes: Array<KeyValue<string, number>>;
  saveText = "Dodaj";
  @Input('field') field: TemplateField = new TemplateField();
  @Input('isEdit') isEdit: boolean = false;
  @Input('templateFields') templateFields: Array<TemplateField>;
  @Input('isCancellable') isCancellable = false;
  @Output('fieldSaved') fieldSaved = new EventEmitter<TemplateField>();
  @Output('cancelled') onCancelled = new EventEmitter<TemplateField>();

  constructor(private templatesService: TemplatesService) {
  }

  ngOnInit() {
    if(this.isEdit){
      this.saveText = "Zapisz";
      this.validateFormula();
    }
  }

  saveField() {
    this.fieldSaved.emit(this.field);
    this.clearField();
  }

  clearField() {
    this.field = new TemplateField();
  }

  cancelled(){
    this.onCancelled.emit();
  }

  validateFormula() {
    this.field.isFormulaValid = false;

    this.templatesService.isFormulaValid(this.field.formula, this.templateFields, this.field.isCalculated)
      .then(result => {
        this.field.isFormulaValid = result === true;
      });
  }
}
