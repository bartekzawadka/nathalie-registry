import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Registry} from "../models/registry";
import {RegistryFilter} from "../models/filters/registry.filter";
import {RegistryEntity} from "../models/registry-entity";

@Injectable({
  providedIn: 'root'
})
export class RegistriesService {

  constructor(private http: HttpClient) { }

  getRegistries(filter: RegistryFilter) {
    return new Promise<any>((resolve, reject) => {
      this.http.post<any>(environment.apiEndpoint+"/registries/list", filter).subscribe(resolve, reject);
    });
  }

  getRegistry(id: string) : Promise<Registry> {
    return new Promise<Registry>((resolve, reject) => {
      this.http.get<Registry>(environment.apiEndpoint + "/registries/"+id).subscribe(resolve, reject);
    })
  }

  getEntityData(registryId: string, templateName: string) : Promise<RegistryEntity>{
    return new Promise<RegistryEntity>((resolve, reject) => {
      this.http.get<RegistryEntity>(environment.apiEndpoint+"/registries/entity/"+registryId+"/"+templateName)
        .subscribe(resolve, reject);
    })
  }

  saveEntityData(registryId: string, data: RegistryEntity) : Promise<any>{
    return new Promise<any>((resolve, reject) => {
      this.http.post(environment.apiEndpoint+"/registries/entity/"+registryId+"/", data).subscribe(resolve, reject);
    })
  }

  saveRegistry(registry: Registry){
    return new Promise<any>((resolve, reject) => {
      if(registry.id){
        this.http.put(environment.apiEndpoint+"/registries/"+registry.id, registry).subscribe(resolve, reject);
      }else{
        this.http.post(environment.apiEndpoint+"/registries", registry).subscribe(resolve, reject);
      }
    })
  }
}
