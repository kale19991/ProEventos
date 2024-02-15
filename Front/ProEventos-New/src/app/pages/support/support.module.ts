import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SupportRoutingModule } from './support-routing.module';
import { SupportComponent } from './support.component';
import { SupportMaterialModule } from 'src/app/shared/material/support-mat.module';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    SupportComponent
  ],
  imports: [
    CommonModule,
    SupportRoutingModule,
    SupportMaterialModule,
    SharedModule
  ]
})
export class SupportModule { }
