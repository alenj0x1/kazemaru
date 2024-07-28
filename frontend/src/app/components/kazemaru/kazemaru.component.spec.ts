import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KazemaruComponent } from './kazemaru.component';

describe('KazemaruComponent', () => {
  let component: KazemaruComponent;
  let fixture: ComponentFixture<KazemaruComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [KazemaruComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(KazemaruComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
