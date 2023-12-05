import React from "react";
import { NavLink } from "react-router-dom";

const Day = ({ hours, day, date }) => {
  return (
    <td class="positive previous">
      <div class="date">
        <span>{day}</span>
      </div>
      <div class="hours">
        <a href="">
          Hours: <span>{hours}</span>
        </a>
      </div>
    </td>
  );
};

export default Day;
