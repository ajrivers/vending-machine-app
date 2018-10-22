import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CoinAcceptorComponent } from './coin-acceptor.component';

describe('CoinAcceptorComponent', () => {
  let component: CoinAcceptorComponent;
  let fixture: ComponentFixture<CoinAcceptorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoinAcceptorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoinAcceptorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
