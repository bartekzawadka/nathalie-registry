import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistryDataComponent } from './registry-data.component';

describe('RegistryDataComponent', () => {
  let component: RegistryDataComponent;
  let fixture: ComponentFixture<RegistryDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistryDataComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistryDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
