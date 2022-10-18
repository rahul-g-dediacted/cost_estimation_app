import React, { useState } from "react";
import {
  PieChart,
  Pie,
  Cell,
  ResponsiveContainer,
  Sector,
  Legend,
} from "recharts";

import _ from "lodash";

const COLORS = [
  "#E06666",
  "#F6B26B",
  "#93C47D",
  "#6FA8DC",
  "#8E7CC3",
  "#999999",
];

const RADIAN = Math.PI / 180;
const renderCustomizedLabel = ({
  cx,
  cy,
  midAngle,
  innerRadius,
  outerRadius,
  percent,
  index,
}) => {
  const radius = innerRadius + (outerRadius - innerRadius) * 0.5;
  const x = cx + radius * Math.cos(-midAngle * RADIAN);
  const y = cy + radius * Math.sin(-midAngle * RADIAN);

  return (
    <text
      x={x}
      y={y}
      fill="white"
      textAnchor={x > cx ? "start" : "end"}
      dominantBaseline="central"
    >
      {`${(percent * 100).toFixed(0)}%`}
    </text>
  );
};

const renderActiveShape = (viewer, props) => {
  const RADIAN = Math.PI / 180;
  const {
    cx,
    cy,
    midAngle,
    innerRadius,
    outerRadius,
    startAngle,
    endAngle,
    payload,
    percent,
    name,
  } = props;
  const sin = Math.sin(-RADIAN * midAngle);
  const cos = Math.cos(-RADIAN * midAngle);
  const sx = cx + (outerRadius + 10) * cos;
  const sy = cy + (outerRadius + 10) * sin;
  const mx = cx + (outerRadius + 30) * cos;
  const my = cy + (outerRadius + 30) * sin;
  const ex = mx + (cos >= 0 ? 1 : -1) * 22;
  const ey = my;
  const textAnchor = cos >= 0 ? "start" : "end";

  const handleClick = (e) => {
    console.log(e);
    let temp = [];
    if (e.data.children) {
      _.forEach(e.data.children, (v) => {
        temp.push(v.id);
      });
      console.log("tem", viewer);
      if (viewer) {
        viewer.isolate(temp);
        viewer.fitToView(temp);
      }
    }
  };
  return (
    <g>
      <text
        x={cx}
        y={cy}
        dy={8}
        textAnchor="middle"
        fill={COLORS[payload.idx % COLORS.length]}
      >
        {`(${(percent * 100).toFixed(2)}%)`}
      </text>
      <Sector
        cx={cx}
        cy={cy}
        innerRadius={innerRadius}
        outerRadius={outerRadius}
        startAngle={startAngle}
        endAngle={endAngle}
        fill={COLORS[payload.idx % COLORS.length]}
        onClick={handleClick.bind(this, payload)}
      />
      <Sector
        cx={cx}
        cy={cy}
        startAngle={startAngle}
        endAngle={endAngle}
        innerRadius={outerRadius + 6}
        outerRadius={outerRadius + 10}
        fill={COLORS[payload.idx % COLORS.length]}
      />
      <path
        d={`M${sx},${sy}L${mx},${my}L${ex},${ey}`}
        stroke={COLORS[payload.idx % COLORS.length]}
        fill="none"
      />
      <circle
        cx={ex}
        cy={ey}
        r={2}
        fill={COLORS[payload.idx % COLORS.length]}
        stroke={COLORS[payload.idx % COLORS.length]}
      />
      <text
        x={ex + (cos >= 0 ? 1 : -1) * 12}
        y={ey}
        textAnchor={textAnchor}
        fill="#333"
      >{`${name}`}</text>
      {/* <text x={ex + (cos >= 0 ? 1 : -1) * 12} y={ey} dy={18} textAnchor={textAnchor} fill="#999">
        {`(${(percent * 100).toFixed(2)}%)`}
      </text> */}
    </g>
  );
};
// dummy hart
export default function PieChartMaterial(props) {
  const [activeIndex, setActiveIndex] = useState(0);
  const handleClick = (e) => {
    console.log(e);
    let temp = [];
    if (e.data.children) {
      _.forEach(e.data.children, (v) => {
        temp.push(v.id);
      });
      props.viewer.isolate(temp);
      props.viewer.fitToView(temp);
    }
  };
  const onPieEnter = (_, index) => {
    setActiveIndex(index);
  };
  return (
    <>
      <ResponsiveContainer>
        <PieChart>
          <Pie
            data={props.data}
            cx="50%"
            cy="50%"
            labelLine={false}
            // label={renderCustomizedLabel}
            outerRadius={150}
            innerRadius={50}
            // fill="#8884d8"
            dataKey="value"
            activeShape={renderActiveShape.bind(this, props.viewer)}
             onMouseEnter={onPieEnter}
            activeIndex={activeIndex}
          >
            {props.data.map((entry, index) => (
              <Cell
                key={`cell-${index}`}
                fill={COLORS[index % COLORS.length]}
                onClick={handleClick.bind(this, entry)}
              />
            ))}
          </Pie>
          {/* <Legend /> */}
        </PieChart>
      </ResponsiveContainer>
    </>
  );
}
