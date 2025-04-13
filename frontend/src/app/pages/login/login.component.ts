import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { DataService } from '../../services/data.service';
import { HttpService } from '../../services/http.service';
import { MessageTypeEnum } from '../../interfaces/IMessage';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  public form: FormGroup;

  constructor(
    private readonly data: DataService,
    private readonly http: HttpService,
    private readonly router: Router,
    private readonly auth: AuthService
  ) {
    this.form = new FormGroup({
      username: new FormControl(null, [Validators.required]),
      password: new FormControl(null, [Validators.required]),
    });
  }

  async onLogin() {
    this.data.loading.emit(true);

    this.http.loginAuth(this.form.value).subscribe({
      next: async ({ data }) => {
        this.data.loading.emit(false);
        this.data.message.emit({
          type: MessageTypeEnum.Success,
          message: 'Session successfully started',
        });

        this.auth.create(data);
        this.data.updateAuth(true);
        await this.router.navigate(['projects']);
      },
      error: (response) => {
        this.data.loading.emit(false);
        this.data.message.emit({
          type: MessageTypeEnum.Error,
          message:
            response?.error?.message ??
            'There was a problem trying to start session',
        });
      },
    });
  }
}
