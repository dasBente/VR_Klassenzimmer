import React from 'react'
import StudentState from './StudentState'
import ToggleAll from './ToggleAll'
import BehaviourControls from './BehaviourControls'

const ClassState = () => {
  const initSocket = () => null;
  const students = []
  const selectAll = () => null;
  const init = () => null;

  return (
    <div>
      <div className='row card-columns'>
        {students.map(s => <StudentState key={s.id} student={s} />)}
      </div>
      <div className='row float-right'><ToggleAll toggle={selectAll} /></div>
      <BehaviourControls />
    </div>
  )
}

export default ClassState
