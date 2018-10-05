import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {ActivatedRoute, Params, Router} from "@angular/router";
import {RegistriesService} from "../../services/registries.service";
import {RegistryEntity} from "../../models/registry-entity";
import {RegistryEntityRow} from "../../models/registry-entity-row";
import {RegistryEntityRowField} from "../../models/registry-entity-row-field";
import {KeyValue} from "../../models/key.value";

@Component({
  selector: 'app-registry-data',
  templateUrl: './registry-data.component.html',
  styleUrls: ['./registry-data.component.scss']
})

export class RegistryDataComponent implements OnInit {

  entity: RegistryEntity = new RegistryEntity();
  currentRow: Array<KeyValue<string, RegistryEntityRowField>> = [];
  entityColumnNames: string[] = [];
  registryId: string;

  constructor(private registriesService: RegistriesService,
              private route: ActivatedRoute,
              private router: Router,
              private changeDetectorRefs: ChangeDetectorRef) {

    this.route.params.subscribe((p: Params) => {
      if (!p || !p['registryId'] || !p['templateName']) {
        return;
      }

      this.registryId = p['registryId'];
      let templateName = p['templateName'];

      this.registriesService.getEntityData(this.registryId, templateName).then(data => {
        if (!data) {
          return;
        }

        this.entity = data;
        if (!this.entity.data) {
          this.entity.data = [];
        }

        this.entityColumnNames = this.entity.template.templateFields.map(f => f.name);

        this.addEmptyRow();
      });
    });
  }

  ngOnInit() {

  }

  addRow() {

    let row = new RegistryEntityRow();
    row.columnValues = this.currentRow.map(field => field.value);

    let data = this.entity.data;
    data.push(row);
    this.entity.data = data;
    this.changeDetectorRefs.detectChanges();
    this.addEmptyRow();
  }

  saveEntity() {
    this.registriesService.saveEntityData(this.registryId, this.entity).then(() => {
        alert('OK');
      },
      e => {
        alert(e);
      });
  }

  addEmptyRow() {
      let row = new RegistryEntityRow();
      row.rowNumber = this.entity.data.length + 1;
      row.columnValues = [];
      for(let k in this.entity.template.templateFields){
        let field = new RegistryEntityRowField();
        field.field = this.entity.template.templateFields[k];
        row.columnValues.push(field);
      }
      this.entity.data.push(row);
  }

  removeRow(index: number){
    this.entity.data.splice(index, 1);
  }
}
