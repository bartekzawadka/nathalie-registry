import {Component, Inject, OnInit} from '@angular/core';
import {DialogResult} from "../../../common/dialog-result";
import {TemplateField} from "../../../models/template.field";
import {MAT_DIALOG_DATA, MatDialog, MatDialogRef} from "@angular/material";
import {TemplateContext} from "../../../models/template-context";

@Component({
  selector: 'app-field-edit',
  templateUrl: './field-edit.component.html',
  styleUrls: ['./field-edit.component.scss']
})
export class FieldEditComponent implements DialogResult<TemplateField> {

  result = new TemplateField();

  constructor(public dialogRef: MatDialogRef<FieldEditComponent>,
              @Inject(MAT_DIALOG_DATA) public data: TemplateContext) {
  }


  saveField(field: TemplateField){
    this.result = field;
    this.dialogRef.close(this.result);
  }

  cancel(){
    this.dialogRef.close();
  }
}
