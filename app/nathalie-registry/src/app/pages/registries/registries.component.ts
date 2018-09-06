import { Component, OnInit } from '@angular/core';
import {RegistriesService} from "../../services/registries.service";
import {Registry} from "../../models/registry";

@Component({
  selector: 'app-registries',
  templateUrl: './registries.component.html',
  styleUrls: ['./registries.component.scss']
})
export class RegistriesComponent implements OnInit {

  displayedColumns: string[] = ['registryDate', 'actionEdit', 'actionDelete'];
  data: Registry[];

  constructor(private registriesService: RegistriesService) { }

  ngOnInit() {
    this.loadData();
  }

  private loadData(){
    this.registriesService.getRegistries().then(data => {
      if(data) {
        this.data = data;
      }
    },error=>{
      console.log(error);
    });
  }

  deleteRegistry(id: string){
    //TODO: Implement
  }
}
