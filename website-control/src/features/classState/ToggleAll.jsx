import React from 'react'

const ToggleAll = () => {
  const toggle = () => null;

  return (
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
}

export default ToggleAll
