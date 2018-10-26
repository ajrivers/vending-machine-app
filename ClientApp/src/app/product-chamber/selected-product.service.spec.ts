import { TestBed, inject } from '@angular/core/testing';

import { SelectedProductService } from './selected-product.service';

describe('SelectedProductService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SelectedProductService]
    });
  });

  it('should be created', inject([SelectedProductService], (service: SelectedProductService) => {
    expect(service).toBeTruthy();
  }));
});
