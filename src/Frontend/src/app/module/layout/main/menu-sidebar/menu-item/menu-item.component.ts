import { Component, HostBinding, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { openCloseAnimation, rotateAnimation } from './menu-item.animation';
import { MenuItem, IMenuItem } from '../../../../../core/interfaces/menu-item';

@Component({
  selector: 'app-menu-item',
  templateUrl: './menu-item.component.html',
  styleUrl: './menu-item.component.sass',
  animations: [openCloseAnimation, rotateAnimation],
})
export class MenuItemComponent implements OnInit {
  // @Input() menuItem: any = null;
  @Input() menuItem!: IMenuItem;
  public isExpandable: boolean = false;
  @HostBinding('class.nav-item') isNavItem: boolean = true;
  @HostBinding('class.menu-open') isMenuExtended: boolean = false;
  public isMainActive: boolean = false;
  public isOneOfChildrenActive: boolean = false;

  constructor(private router: Router) {}

  ngOnInit(): void {
    if (this.menuItem?.children?.length! > 0) {
      this.isExpandable = true;
    }
    this.calculateIsActive(this.router.url);
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe((event: any) => {
        this.calculateIsActive(event.url);
      });
  }

  public handleMainMenuAction() {
    if (this.isExpandable) {
      this.toggleMenu();
      return;
    }
    this.router.navigate(this.menuItem.path);
  }

  public toggleMenu() {
    this.isMenuExtended = !this.isMenuExtended;
  }

  public calculateIsActive(url: string) {
    this.isMainActive = false;
    this.isOneOfChildrenActive = false;
    if (this.isExpandable) {
      if (this.menuItem.children != null)
        this.menuItem.children.forEach((item) => {
          if (item.path[0] === url) {
            this.isOneOfChildrenActive = true;
            this.isMenuExtended = true;
          }
        });
    } else if (this.menuItem.path[0] === url) {
      this.isMainActive = true;
    }
    if (!this.isMainActive && !this.isOneOfChildrenActive) {
      this.isMenuExtended = false;
    }
  }
}
