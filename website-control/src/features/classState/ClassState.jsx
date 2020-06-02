import React from 'react'
import StudentState from './StudentState'
import ToggleAll from './ToggleAll'
import BehaviourControls from './BehaviourControls'
import { useSelector } from 'react-redux'
import { selectStudents } from './studentsSlice'

const ClassState = () => {
  const students = useSelector(selectStudents)

  return (
    <div>
      <div className='row card-columns'>
        {students.map(s => <StudentState key={s.id} student={s} />)}
      </div>
      <div className='row float-right'><ToggleAll /></div>
      <BehaviourControls />
    </div>
  )
}

export default ClassState
