import { Component, OnInit } from '@angular/core';
import {TemplatesService} from "../../services/templates.service";

@Component({
  selector: 'app-templates',
  templateUrl: './templates.component.html',
  styleUrls: ['./templates.component.scss']
})
export class TemplatesComponent implements OnInit {

  data: any;

  constructor(private templatesService: TemplatesService) { }

  ngOnInit() {
    this.loadData();
  }

  private loadData(){
    this.templatesService.getTemplates().then(data=>{this.data = data}, error => {
      console.log(error);
    });
  }
}
