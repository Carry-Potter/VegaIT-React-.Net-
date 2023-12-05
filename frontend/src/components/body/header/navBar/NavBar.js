import React from 'react';
import {
  Nav,
  NavLink,
  Bars,
  NavMenu,
  NavBtn,
  NavBtnLink,
} from './NavbarElements';

import logo from "../../../../assets/img/logo.png"

const NavBar = () => {
    return (
      <header class="header">
			<div class="top-bar"></div>
			<div class="wrapper">
				<a href="timesheet" class="logo">
						<img src={logo} alt="Logo" />
				</a>
				<ul class="user right">
					<li>
						<a href="javascript:;">Sladjana Miljanovic</a>
						<div class="invisible"></div>
						<div class="user-menu">
							<ul>
								<li>
									<a href="javascript:;" class="link">Change password</a>
								</li>
								<li>
									<a href="javascript:;" class="link">Settings</a>
								</li>
								<li>
									<a href="javascript:;" class="link">Export all data</a>
								</li>
							</ul>
						</div>
					</li>
					<li class="last">
						<a href="javascript:;">Logout</a>
					</li>
				</ul>
				<nav>
					<ul class="menu">
						<li>
							
							<NavLink to="/timesheet" className="btn nav" activeClassName="active">TimeSheet</NavLink>
						</li>
						<li>
							
							<NavLink to="/client" className="btn nav" activeClassName="active">Client</NavLink>
						</li>
						<li>
							
							<NavLink to="/project" className="btn nav" activeClassName="active">Projects</NavLink>
						</li>
						<li>
							
							<NavLink to="/category" className="btn nav" activeClassName="active">Categories</NavLink>
						</li>
						<li>
							
							<NavLink to="/teammember" className="btn nav" activeClassName="active">Team members</NavLink>
						</li>
						<li class="last">
							
							<NavLink to="/report" className="btn nav" activeClassName="active">Reports</NavLink>
						</li>
					</ul>
					<div class="mobile-menu">
						<a href="javascript:;" class="menu-btn">
							<i class="zmdi zmdi-menu"></i>
						</a>
						<ul>
							<li>
								<a href="javascript:;">TimeSheet</a>
							</li>
							<li>
								<a href="javascript:;">Clients</a>
							</li>
							<li>
								<a href="javascript:;">Projects</a>
							</li>
							<li>
								<a href="javascript:;">Categories</a>
							</li>
							<li>
								<a href="javascript:;">Team members</a>
							</li>
							<li class="last">
								<a href="javascript:;">Reports</a>
							</li>
						</ul>
					</div>					
					<span class="line"></span>
				</nav>
			</div>
		</header>
    )
}
export default NavBar