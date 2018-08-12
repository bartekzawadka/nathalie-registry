import { Component, OnInit } from '@angular/core';
import {RegistriesService} from "../../services/registries.service";

@Component({
  selector: 'app-registries',
  templateUrl: './registries.component.html',
  styleUrls: ['./registries.component.scss']
})
export class RegistriesComponent implements OnInit {

  data: any;

  constructor(private registriesService: RegistriesService) { }

  ngOnInit() {
    this.loadData();
  }

  private loadData(){
    this.registriesService.getRegistries().then(data => {
      this.data = data;
    },error=>{
      console.log(error);
    });
  }
}
