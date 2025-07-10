import { importProvidersFrom } from '@angular/core';
import { RouterModule } from '@angular/router';
import { appRoutingProviders } from './app/app-routing.module';
import { AppComponent } from './app/app.component';
import { bootstrapApplication } from '@angular/platform-browser';

bootstrapApplication(AppComponent, {
  providers: [...appRoutingProviders]
})
.catch(err => console.error(err));
