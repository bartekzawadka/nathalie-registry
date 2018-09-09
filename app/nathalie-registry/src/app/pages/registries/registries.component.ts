import { Component, OnInit } from '@angular/core';
import {RegistriesService} from "../../services/registries.service";
import {Registry} from "../../models/registry";
import {RegistryFilter} from "../../models/filters/registry.filter";

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

  deleteRegistry(id: string){
    //TODO: Implement
  }
}
