import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectThumbComponent } from './project-thumb.component';

describe('ProjectThumbComponent', () => {
  let component: ProjectThumbComponent;
  let fixture: ComponentFixture<ProjectThumbComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProjectThumbComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProjectThumbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
