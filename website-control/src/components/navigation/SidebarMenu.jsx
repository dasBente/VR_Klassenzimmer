import React from 'react'

const SidebarMenu = () => (
  <nav id='sidebarMenu' className='col-md-3 col-lg-2 d-md-block bg-light sidebar collapse'>
    <div className='sidebar-sticky pt-3'>
      <ul className='nav flex-column'>
        <li className='nav-item'>
          <a className='nav-link active' href='#'>
            {/* Add icon maybe? */}
            Dashboard
          </a>
        </li>
      </ul>
    </div>
  </nav>
)

export default SidebarMenu
