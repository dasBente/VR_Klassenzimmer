import React from 'react'
import PropTypes from 'prop-types'

const ToggleAll = ({ toggle }) => (
  <div className='btn-group' role='group' aria-label='Alle Lerner aus oder abwählen'>
    <button
      className='btn btn-outline-primary' type='button' onClick={() => toggle(false)}
    >
      Alle abwählen
    </button>
    <button className='btn btn-primary' type='button' onClick={() => toggle(true)}>
      Alle auswählen
    </button>
  </div>
)

ToggleAll.propTypes = {
  toggle: PropTypes.func
}

export default ToggleAll
