import { Component, OnInit } from '@angular/core';
import {TemplatesService} from "../../services/templates.service";
import {Template} from "../../models/template";
import {TemplateFilter} from "../../models/filters/template.filter";

@Component({
  selector: 'app-templates',
  templateUrl: './templates.component.html',
  styleUrls: ['./templates.component.scss']
})
export class TemplatesComponent implements OnInit {
  displayedColumns: string[] = ['name', 'isEnabled', 'actionEdit', 'actionDelete'];
  data: Template[];
  filter: TemplateFilter = new TemplateFilter();

  constructor(private templatesService: TemplatesService) { }

  ngOnInit() {
    this.loadData();
  }

  private loadData() {
    this.templatesService.getTemplates(this.filter).then(data=>{
      for(let k in data){
        if(data.hasOwnProperty(k)) {
          data[k].enabledColor = data[k].isEnabled ? "primary" : "warn";
          data[k].enabledIcon = data[k].isEnabled ? "check" : "close";
        }
      }
      this.data = data;
    }, error => {
      console.log(error);
    });
  }

  deleteTemplate(id: string){
    this.templatesService.deleteTemplate(id).then(()=>{
      this.loadData();
    })
  }
}
