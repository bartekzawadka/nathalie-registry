import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Registry} from "../models/registry";

@Injectable({
  providedIn: 'root'
})
export class RegistriesService {

  constructor(private http: HttpClient) { }

  getRegistries() {
    return new Promise<any>((resolve, reject) => {
      this.http.get<any>(environment.apiEndpoint+"/registries").subscribe(resolve, reject);
    });
  }

  getRegistry(id: string) : Promise<Registry> {
    return new Promise<Registry>((resolve, reject) => {
      this.http.get<Registry>(environment.apiEndpoint + "/registries/"+id).subscribe(resolve, reject);
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
