import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { StajYonComponent } from './staj-yon/staj-yon.component';
import { StajDefComponent } from './staj-def/staj-def.component';
import { FormlarComponent } from './formlar/formlar.component';
import { IgBelgeComponent } from './ig-belge/ig-belge.component';
import { LoginComponent } from './login/login.component';

export const routes: Routes = [
 { path: '', component: HomeComponent },
 { path: 'staj-yon', component: StajYonComponent },
 { path: 'staj-def', component: StajDefComponent },
 { path: 'formlar', component: FormlarComponent },
 { path: 'ig-belge', component: IgBelgeComponent },
 { path: 'login', component: LoginComponent },
];