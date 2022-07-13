import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BaseFieldComponent } from './base-field.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';



@NgModule({
  declarations: [BaseFieldComponent],
  imports: [
    CommonModule,
    FormsModule,      
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    FlexLayoutModule,
    MatAutocompleteModule
  ],
  exports: [BaseFieldComponent]
})
export class BaseFieldModule { }
