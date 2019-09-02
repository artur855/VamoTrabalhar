import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddMedicComponent } from './Pages/medico/add/addMedic.component';
import { ListMedicComponent } from './Pages/medico/list/listMedic.component';
import { EditMedicComponent } from './Pages/medico/edit/editMedic.component';
import { ListpatComponent } from './Pages/patient/listpat/listpat.component';
import { EditpatComponent } from './Pages/patient/editpat/editpat.component';
import { AddpatComponent } from './Pages/patient/addpat/addpat.component';
import { HomeComponent } from './Pages/home/home.component';
import { DashboardComponent } from './Pages/dashboard/dashboard.component';
import { AuthGuard } from './Guards/auth.guard';
import { PedidoexameComponent } from './Pages/exame/addexame/pedidoexame.component';
import { EditexameComponent } from './Pages/exame/editexame/editexame.component';
import { ListexameComponent } from './Pages/exame/listexame/listexame.component';


const routes: Routes = [
  { path: 'listar-medico', component: ListMedicComponent, canActivate: [AuthGuard] },
  { path: 'add-medico', component: AddMedicComponent, canActivate: [AuthGuard] },
  { path: 'edit-medico', component: EditMedicComponent, canActivate: [AuthGuard] },

  { path: 'list-patient', component: ListpatComponent, canActivate: [AuthGuard] },
  { path: 'edit-patient', component: EditpatComponent, canActivate: [AuthGuard] },
  { path: 'add-patient', component: AddpatComponent, canActivate: [AuthGuard] },

  { path: 'list-exam-request', component: ListexameComponent,canActivate: [AuthGuard] },
  { path: 'add-exam-request', component: PedidoexameComponent,canActivate: [AuthGuard] },
  { path: 'edit-exam-request', component: EditexameComponent,canActivate: [AuthGuard] },
  
  { path: '', component: HomeComponent },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
