import { Component, OnInit } from '@angular/core';
import {RegistriesService} from "../../services/registries.service";
import {Registry} from "../../models/registry";
import {RegistryFilter} from "../../models/filters/registry.filter";
import {RegistryEntity} from "../../models/registry-entity";

@Component({
  selector: 'app-registries',
  templateUrl: './registries.component.html',
  styleUrls: ['./registries.component.scss']
})
export class RegistriesComponent implements OnInit {
  data: Registry[];
  filter: RegistryFilter = new RegistryFilter();

  constructor(private registriesService: RegistriesService) { }

  ngOnInit() {
    this.loadData();
  }

  private loadData(){
    this.registriesService.getRegistries(this.filter).then(data => {
      if(data) {
        this.data = data;
      }
    },error=>{
      console.log(error);
    });
  }

  refresh(){
    this.loadData();
  }

  getCounterDescription(entity: RegistryEntity){
    if(entity.dataIds && (entity.dataIds.length > 1 && entity.dataIds.length <= 4)) {
      return "wiersze";
    }
    if(entity.dataIds && entity.dataIds.length == 1){
      return "wiersz";
    }

    return "wierszy";
  }

  editEntity(){

  }

  deleteRegistry(id: string){
    //TODO: Implement
  }
}
