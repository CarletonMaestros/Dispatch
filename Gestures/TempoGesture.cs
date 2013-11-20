﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Kinect;

namespace Orchestra
{
    public class TempoGesture
    {
        public class CircularQueue<X>
        {
            private X[] queueStorage;
            private int firstElementIndex;
            private int capacity;
            private int numElements;

            public CircularQueue(int size)
            {
                queueStorage = new X[size];
                capacity = size;
                firstElementIndex = 0;
            }

            public void enqueue(X element)
            {
                if (numElements < capacity)
                {
                    queueStorage[firstElementIndex + numElements] = element;
                    numElements++;
                }
                else if (numElements == capacity)
                {
                    queueStorage[firstElementIndex] = element;
                    firstElementIndex = (firstElementIndex + 1) % capacity;
                }
            }

            public X get(int index)
            {
                return queueStorage[(firstElementIndex + capacity - index - 1) % capacity];
            }


            public Boolean isFull()
            {
                if (numElements == capacity)
                {
                    return true;
                }
                return false;
            }

            public int contains(X item)
            {
                for (int index = 0; index < capacity; index++)
                {
                    if (queueStorage[(firstElementIndex + capacity - index - 1) % capacity].Equals(item))
                    {
                        return index;
                    }
                }
                return -1;
            }

            public int getLength()
            {
                return numElements;
            }
        }

        public Int32 counter = 1;
        public Stopwatch stopwatch;
        public String seeking;
        public float prevYOne;
        public float prevYTwo;
        public float prevXOne;
        public float prevXTwo;
        public float rightHandY;
        public float rightHandX;
        public float threshold;
        public Boolean conducting;
        public CircularQueue<string> recentEvents;
        public int stillFramesCount;
        public int framesInFirstBeat;
        public float headX;
        public float headY;
        public int startMarker = 0;
        //public CircularQueue<List<float>> circleChecker;
        public Boolean stop = false;
        //public List<float> xYValue();
        //public float xAverage = 0;
        //public float yAverage = 0;

        public TempoGesture()
        {
            Dispatch.SkeletonMoved += this.SkeletonMoved;
            recentEvents = new CircularQueue<string>(20);
            stopwatch = new Stopwatch();
            counter = 0;
            seeking = "STILL";
            threshold = .002F;
            stillFramesCount = 0;
            framesInFirstBeat = 0;
            //circleChecker = new CircularQueue<List<float>>(30);
        }

        ~TempoGesture()
        {
            Dispatch.SkeletonMoved -= this.SkeletonMoved;
        }

        void SkeletonMoved(float time, Skeleton skel)
        {
            foreach (Joint joint in skel.Joints)
            {
                if (joint.JointType == JointType.HandRight)
                {
                    rightHandY = joint.Position.Y;
                    rightHandX = joint.Position.X;
                    //xYValue().Add(rightHandX);
                    //xYValue().Add(rightHandY);
                    //circleChecker.enqueue(xYValue());
                    //xAverage = xYValue().ElementAt(0);
                    //yAverage = xYValue().ElementAt(1);
                    //xYValue().Clear();
                    //for (int i = 1; i <= circleChecker.getLength(); i++)
                    //{
                    //    xYValue().Add(circleChecker.get(i).ElementAt(0));
                    //    xAverage += xYValue().ElementAt(0);
                    //    yAverage += xYValue().ElementAt(1);
                    //    xYValue().Clear();
                    //}
                    //xAverage = xAverage / circleChecker.getLength();
                    //yAverage = yAverage / circleChecker.getLength();
                    
                }
            }
            if (!stop)
            {
                switch (seeking)
                {
                    case "STILL":
                        {
                            if (stillFramesCount == 15)
                            {
                                seeking = "START";
                            }
                            if (stillFramesCount < 15 && Math.Abs(prevXOne - rightHandX) < .08 && Math.Abs(prevYOne - rightHandY) < .08 && Math.Abs(prevXTwo - rightHandX) < .08 && Math.Abs(prevYTwo - rightHandY) < .08)
                            {
                                stillFramesCount++;
                                break;
                            }
                            else if (stillFramesCount < 15)
                            {
                                stillFramesCount = 0;
                            }
                            break;
                        }
                    case "START":
                        {
                            if (prevYTwo < (prevYOne - .01) && prevYOne < (rightHandY - .01))
                            {
                                if (framesInFirstBeat == 0)
                                {
                                    stopwatch.Start();
                                }

                                framesInFirstBeat++;
                                break;
                            }
                            if (framesInFirstBeat >= 2 && prevYTwo > (prevYOne + .01) && prevYOne > (rightHandY + .01))
                            {
                                //Console.WriteLine("Start with " + stopwatch.ElapsedMilliseconds + " in the pre-start beat.");
                                seeking = "MINIMUM";
                                break;
                            }

                            break;
                        }
                    case "MINIMUM":
                        {
                            if (prevYTwo < (prevYOne - threshold) && prevYOne < (rightHandY - threshold))
                            {
                                if (counter == 5)
                                {
                                    counter = 1;
                                }
                                if (startMarker == 0)
                                {
                                    startMarker = 1;
                                    long firstTempo = stopwatch.ElapsedMilliseconds * 1000 / 2;
                                    //Console.WriteLine(counter + " " + firstTempo);
                                    //Dispatch.TriggerPlay(); // FIXME!!!
                                    Dispatch.TriggerBeat(counter);
                                }
                                else
                                {
                                    long tempo = stopwatch.ElapsedMilliseconds * 1000;
                                    //Console.WriteLine(counter + " " + tempo);
                                    Dispatch.TriggerBeat(counter);
                                }
                                stopwatch.Restart();

                                // GET OVER IT
                                seeking = "MAXIMUM";
                                counter++;
                                break;
                            }
                            break;
                        }
                    case "MAXIMUM":
                        {
                            if (prevYTwo > (prevYOne + threshold) && prevYOne > (rightHandY + threshold))
                            {
                                seeking = "MINIMUM";
                                break;
                            }
                            break;
                        }


                }
            }
            prevYTwo = prevYOne;
            prevXTwo = prevXOne;
            prevYOne = rightHandY;
            prevXOne = rightHandX;
        }
    }
}