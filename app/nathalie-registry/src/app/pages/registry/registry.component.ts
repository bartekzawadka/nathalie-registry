import {Component, OnInit} from '@angular/core';
import {Registry} from "../../models/registry";
import {Template} from "../../models/template";
import {TemplatesService} from "../../services/templates.service";
import {SelectableListItem} from "../../common/selectable-list-item";
import {RegistriesService} from "../../services/registries.service";
import {ActivatedRoute, Params, Router} from "@angular/router";

@Component({
  selector: 'app-registry',
  templateUrl: './registry.component.html',
  styleUrls: ['./registry.component.scss']
})
export class RegistryComponent implements OnInit {

  registry: Registry = new Registry();
  //templates: Array<Template> = [];
  selectedTemplates: Array<SelectableListItem<Template>> = [];

  constructor(private templatesService: TemplatesService,
              private registriesService: RegistriesService,
              private route: ActivatedRoute,
              private router: Router) {
    this.route.params.subscribe((p: Params) => {
      if (!p || !p['id']) {
        return;
      }

      this.registriesService.getRegistry(p['id']).then(data => {
        this.registry = data;
        this.loadTemplates();
      }, error => {
        alert(error);
      });
    })
  }

  ngOnInit() {
    this.loadTemplates();
  }

  loadTemplates() {
    this.templatesService.getTemplates().then(data => {
      if (!data) {
        return;
      }

      let templates: any = data;
      let items: Array<SelectableListItem<Template>> = [];

      for (let k in templates) {
        let item = new SelectableListItem(templates[k]);

        if (this.registry.templates) {
          let isExisting = this.registry.templates.findIndex(t => t.id == templates[k].id) >= 0;
          item.isEnabled = !isExisting;
          item.isSelected = isExisting;
        }

        items.push(item);
      }

      this.selectedTemplates = items;
    });
  }

  templatesSelected() {
    if (!this.selectedTemplates || this.selectedTemplates.length == 0) {
      return false;
    }

    return this.selectedTemplates.filter(f => f.isSelected).length > 0;
  }

  submit() {
    let array: Array<Template> = [];
    for (let k in this.selectedTemplates) {
      if(this.selectedTemplates[k].isSelected) {
        array.push(this.selectedTemplates[k].item);
      }
    }

    this.registry.templates = array;

    this.registriesService.saveRegistry(this.registry).then(() => {
      alert("OK");
      this.router.navigate(['/registries']);
    })
  }
}
