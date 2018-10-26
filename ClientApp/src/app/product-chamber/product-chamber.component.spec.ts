import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductChamberComponent } from './product-chamber.component';

describe('ProductChamberComponent', () => {
  let component: ProductChamberComponent;
  let fixture: ComponentFixture<ProductChamberComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductChamberComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductChamberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
